using System;
using System.IO;
using System.Xml;
using Syroot.Windows.IO;

namespace Crazy_Software.Downloaders.Queue_Downloader
{
    public enum NotificationLevel
    {
        ShowAllNotifications,
        ShowImportantOnly,
        NoNotifications
    }

    public enum DeleteLevel
    {
        DeleteOnSkipAndStop,
        DeleteOnSkip,
        DeleteOnStop,
        NoDelete
    }

    public static class Settings
    {
        private static string _settingsFilePath = Path.Combine(new KnownFolder(KnownFolderType.RoamingAppData).Path, @"Crazy Software\Queue Downloader\Settings.xml");
        private static string _defaultDirectory;

        private static long _maxSpeed = 0;

        private static byte[] _bufferSize;

        private static NotificationLevel _notificationLevel;
        private static DeleteLevel _deleteLevel;

        public static string DefaultDirectory
        {
            get { return _defaultDirectory; }
        }

        public static long MaxSpeed
        {
            get { return _maxSpeed; }
        }

        public static byte[] BufferSize
        {
            get { return _bufferSize; }
        }

        public static NotificationLevel NotificationLevel
        {
            get { return _notificationLevel; }
        }

        public static DeleteLevel DeleteLevel
        {
            get { return _deleteLevel; }
        }

        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static void Load()
        {
            if (!File.Exists(_settingsFilePath))
            {
                _defaultDirectory = new KnownFolder(KnownFolderType.Downloads).Path;
                _maxSpeed = 0;
                _bufferSize = new byte[16 * 1024];
                _notificationLevel = NotificationLevel.ShowImportantOnly;
                _deleteLevel = DeleteLevel.NoDelete;

                Save(_defaultDirectory, _maxSpeed, _bufferSize, _notificationLevel, _deleteLevel);
            }
            else
            {
                var xmlSettings = new XmlDocument();
                xmlSettings.Load(_settingsFilePath);

                var nodeList = xmlSettings.SelectNodes("/Settings");

                foreach (XmlNode node in nodeList)
                {
                    _defaultDirectory = node.SelectSingleNode("DefaultDirectory").InnerText;
                    _maxSpeed = Convert.ToInt64(node.SelectSingleNode("MaxSpeed").InnerText);
                    _bufferSize = new byte[Convert.ToInt32(node.SelectSingleNode("BufferSize").InnerText)];
                    _notificationLevel = ParseEnum<NotificationLevel>(node.SelectSingleNode("NotificationLevel").InnerText);
                    _deleteLevel = ParseEnum<DeleteLevel>(node.SelectSingleNode("DeleteLevel").InnerText);
                }
            }
        }

        public static void Save(string defaultDirectory, long maxSpeed, byte[] bufferSize, NotificationLevel notificationLevel, DeleteLevel deleteLevel)
        {
            using (var fileStream = new FileStream(_settingsFilePath, FileMode.Create, FileAccess.Write))
            using (var settingsWriter = XmlWriter.Create(fileStream))
            {
                if (_defaultDirectory != defaultDirectory)
                    _defaultDirectory = defaultDirectory;

                if (_maxSpeed != maxSpeed)
                    _maxSpeed = maxSpeed;

                if (_bufferSize != bufferSize)
                    _bufferSize = bufferSize;

                if (_notificationLevel != notificationLevel)
                _notificationLevel = notificationLevel;

                if (_deleteLevel != deleteLevel)
                    _deleteLevel = deleteLevel;

                settingsWriter.WriteStartDocument();
                settingsWriter.WriteComment("This is the settings for Queue Downloader. Do NOT modify this file, unless you know what you are doing!");
                settingsWriter.WriteStartElement("Settings");
                settingsWriter.WriteElementString("DefaultDirectory", defaultDirectory);
                settingsWriter.WriteElementString("MaxSpeed", maxSpeed.ToString());
                settingsWriter.WriteElementString("BufferSize", bufferSize.Length.ToString());
                settingsWriter.WriteElementString("NotificationLevel", notificationLevel.ToString());
                settingsWriter.WriteElementString("DeleteLevel", deleteLevel.ToString());
                settingsWriter.WriteEndElement();
                settingsWriter.WriteEndDocument();
            }
        }
    }
}
