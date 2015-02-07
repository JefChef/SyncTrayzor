﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SyncTrayzor.Services
{
    public class FolderConfiguration
    {
        public string ID { get; set; }
        public bool IsWatched { get; set; }

        public FolderConfiguration()
        { }

        public FolderConfiguration(string id, bool isWatched)
        {
            this.ID = id;
            this.IsWatched = isWatched;
        }

        public FolderConfiguration(FolderConfiguration other)
        {
            this.ID = other.ID;
            this.IsWatched = other.IsWatched;
        }
    }


    [XmlRoot("Configuration")]
    public class Configuration
    {
        public string SyncThingPath { get; set; }
        public bool ShowTrayIconOnlyOnClose { get; set; }
        public bool CloseToTray { get; set; }
        public bool ShowSynchronizedBalloon { get; set; }
        public string SyncThingAddress { get; set; }
        public bool StartOnLogon { get; set; }
        public bool StartMinimized { get; set; }
        public bool StartSyncThingAutomatically { get; set; }
        [XmlArrayItem("Folder")]
        public List<FolderConfiguration> Folders { get; set; }

        public Configuration()
            : this("")
        { }

        public Configuration(string basePath)
        {
            this.SyncThingPath = Path.Combine(basePath, "syncthing.exe");
            this.ShowTrayIconOnlyOnClose = false;
            this.CloseToTray = true;
            this.ShowSynchronizedBalloon = true;
            this.SyncThingAddress = "http://localhost:8384";
            this.StartOnLogon = false;
            this.StartMinimized = true;
            this.StartSyncThingAutomatically = true;
            this.Folders = new List<FolderConfiguration>();
        }

        public Configuration(Configuration other)
        {
            this.SyncThingPath = other.SyncThingPath;
            this.ShowTrayIconOnlyOnClose = other.ShowTrayIconOnlyOnClose;
            this.CloseToTray = other.CloseToTray;
            this.ShowSynchronizedBalloon = other.ShowSynchronizedBalloon;
            this.SyncThingAddress = other.SyncThingAddress;
            this.StartOnLogon = other.StartOnLogon;
            this.StartMinimized = other.StartMinimized;
            this.StartSyncThingAutomatically = other.StartSyncThingAutomatically;
            this.Folders = other.Folders.Select(x => new FolderConfiguration(x)).ToList();
        }
    }
}