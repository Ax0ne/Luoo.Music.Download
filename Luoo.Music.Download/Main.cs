using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Luoo.Music.Download
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn_AddVolume_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_vol.Text.Trim()))
            {
                int iv;
                var isInt = int.TryParse(txt_vol.Text, out iv);
                if (!isInt)
                {
                    MessageBox.Show("请输入1-4位的纯数字", "提示");
                    return;
                }
                lbl_vols.Text += (string.IsNullOrEmpty(lbl_vols.Text.Trim()) ? "" : ",") + txt_vol.Text;
                if (!string.IsNullOrEmpty(txt_SNumber.Text.Trim()))
                {
                    _songNumber.Add(txt_vol.Text, txt_SNumber.Text);
                    lbl_vols.Text = lbl_vols.Text + "（" + txt_SNumber.Text + "）";
                    _volQueue.Enqueue(txt_vol.Text.Trim());
                }
                else
                {
                    _volQueue.Enqueue(txt_vol.Text.Trim());
                }
                txt_vol.Clear();
                btn_Download.Enabled = true;
                txt_SNumber.Clear();
            }
        }

        private readonly Queue<string> _volQueue = new Queue<string>();
        private readonly Dictionary<string, string> _songNumber = new Dictionary<string, string>();
        private const string _luooUrl = "http://www.luoo.net/music/";
        private const string _luooMusicUrl = "http://emo.luoo.net/low/luoo/radio{0}/{1}.mp3";
        private const string _songName = "<a href=\"javascript:;\" rel=\"nofollow\" class=\"trackname btn-play\">(.*)</a>";
        private const string _artist = "<span class=\"artist btn-play\">(.*)</span>";
        private const string _spiltChar = "@";
        private readonly string _saveDirectory = Environment.CurrentDirectory + "\\MusicList\\";
        private readonly Dictionary<string, string> _songUrlTable = new Dictionary<string, string>();
        private readonly List<string> _currentTask = new List<string>();
        private void btn_Download_Click(object sender, EventArgs e)
        {
            //var _volQueue = new Queue<string>(lbl_vols.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            if (_volQueue.Count == 0) return;
            EnableControls(false);
            if (!Directory.Exists(_saveDirectory))
            {
                Directory.CreateDirectory(_saveDirectory);
            }
            while (_volQueue.Any())
            {
                var vol = _volQueue.Dequeue();
                var volUrl = _luooUrl + vol;
                var webClient = new WebClient { Encoding = Encoding.UTF8 };
                var luooHtml = webClient.DownloadString(volUrl);
                var regex = new Regex(_songName, RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
                var matchResults = regex.Matches(luooHtml);
                var regex1 = new Regex(_artist, RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
                var matchArtistResults = regex1.Matches(luooHtml);
                if (matchResults.Count != matchArtistResults.Count) break;
                var songUrlAndName = string.Empty;
                var songNumbers = _songNumber.Any() ? _songNumber.First(s => s.Key == vol).Value : "";
                var songNumberArray = songNumbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < matchResults.Count; i++)
                {
                    if (matchResults[i].Groups.Count == 2)
                    {
                        var song = matchResults[i].Groups[1].Value;
                        var songSpilt = song.Split(new[] { ". " }, StringSplitOptions.RemoveEmptyEntries);
                        if (songNumberArray.Any() && !songNumberArray.Select(s => Convert.ToInt32(s)).Contains(Convert.ToInt32(songSpilt[0])))
                        {
                            continue;
                        }
                        if (songSpilt.Length == 2)
                        {
                            songUrlAndName = string.Format(_luooMusicUrl, int.Parse(vol), songSpilt[0]) + _spiltChar + songSpilt[1];
                        }
                    }
                    if (matchArtistResults[i].Groups.Count == 2)
                    {
                        var artist = matchArtistResults[i].Groups[1].Value;
                        songUrlAndName += " - " + artist;
                    }
                    _songUrlTable.Add(vol + "," + i, songUrlAndName);
                }
                ThreadPool.QueueUserWorkItem(
                    w =>
                    {
                        var volId = (string)w;
                        var taskList = _songUrlTable.Where(p => p.Key.Contains(volId + ",")).Select(s => s.Value).ToList();
                        var download = new WebClient();
                        foreach (var task in taskList)
                        {
                            _currentTask.Add(task);
                            SetText("[ " + _currentTask.Count + " ]首");
                            var urlAndName = task.Split(new[] { _spiltChar }, StringSplitOptions.RemoveEmptyEntries);
                            download.DownloadFile(urlAndName[0], _saveDirectory + urlAndName[1] + ".mp3");
                            if (_songUrlTable.Count == _currentTask.Count)
                            {
                                SetText("下载已完成");
                                SetVolsText("");
                                AsyncEnableControls(true);
                                _songUrlTable.Clear();
                                _currentTask.Clear();
                                _songNumber.Clear();
                            }
                        }
                    }, vol);
            }
        }

        private delegate void SetCurrentTaskText(string text);
        private delegate void SetLblVolsText(string text);
        private delegate void SetEnableControl(bool isEnable);

        void SetVolsText(string text)
        {
            if (lbl_vols.InvokeRequired)
            {
                var setLblVolsText = new SetLblVolsText(SetVolsText);
                lbl_vols.Invoke(setLblVolsText, text);
            }
            else
            {
                lbl_vols.Text = text;
            }
        }
        void SetText(string text)
        {
            if (lbl_CurrentText.InvokeRequired)
            {
                var setCurrentTaskText = new SetCurrentTaskText(SetText);
                lbl_CurrentText.Invoke(setCurrentTaskText, text);
            }
            else
            {
                lbl_CurrentText.Text = text;
            }
        }

        void EnableControls(bool isEnable)
        {
            for (int c = 0; c < Controls.Count; c++)
            {
                if (Controls[c].Name == "lbl_CurrentText") continue;
                Controls[c].Enabled = isEnable;
            }
        }
        void AsyncEnableControls(bool isEnable)
        {
            for (int c = 0; c < Controls.Count; c++)
            {
                var control = Controls[c];
                if (control.Name == "btn_Download")
                {
                    isEnable = false;
                }
                else
                {
                    isEnable = true;
                }
                if (control.InvokeRequired)
                {
                    var setEnableControl = new SetEnableControl(EnableControls);
                    control.Invoke(setEnableControl, isEnable);
                }
                else
                {
                    control.Enabled = isEnable;
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_songUrlTable.Count != _currentTask.Count)
            {
                var result = MessageBox.Show("还有任务未完成确定要关闭吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                e.Cancel = result == DialogResult.Cancel;
            }
            
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
