﻿using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared
{
#pragma warning disable CS8618, CS8602 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public abstract class BaseExcelReader<Self, Scheme>
    {
        public Scheme[] All { get; set; }
        public abstract string FileName { get; }

        private static Self Instance;

        public static Self GetInstance()
        {
            Instance ??= Activator.CreateInstance<Self>();

            if ((Instance as BaseExcelReader<Self, Scheme>).All == null)
            {
                (Instance as BaseExcelReader<Self, Scheme>).Load();
            }

            return Instance;
        }

        public void Load()
        {
            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            All = JsonConvert.DeserializeObject<Scheme[]>(path) ?? Array.Empty<Scheme>();
        }

#pragma warning restore CS8618, CS8602 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}