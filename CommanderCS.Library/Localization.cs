using CommanderCS.Library.Enums;
using System.Reflection;
using System.Text;

namespace CommanderCS.Library
{
    public static class Localization
    {
        public delegate byte[] LoadFunction(string path);

        public delegate void OnLocalizeNotification();

        public static LoadFunction loadFunction;

        public static OnLocalizeNotification onLocalize;

        public static bool localizationHasBeenSet = false;

        private static string[] mLanguages = null;

        private static Dictionary<string, string> mOldDictionary = [];

        private static Dictionary<string, string[]> mDictionary = [];

        private static Dictionary<string, string[]> mTutorialDictionary = [];

        private static Dictionary<string, string[]> mTalkDictionary = [];

        private static Dictionary<string, string[]> mScenarioDictionary = [];

        private static Dictionary<string, string[]> mEventDictionary = [];

        private static Dictionary<string, string[]> mInfinityDictionary = [];

        private static int mLanguageIndex = -1;

        private static string mLanguage;

        private const int tutorialIndex = 50000;

        private const int talkIndex = 60000;

        private const int talkIndexEnd = 70000;

        private static bool mMerging = false;

        public static string language
        {
            get
            {
                if (string.IsNullOrEmpty(mLanguage))
                {
                    mLanguage = "S_En";
                    LoadAndSelect(mLanguage);
                }
                return mLanguage;
            }
            set
            {
                if (mLanguage != value)
                {
                    mLanguage = value;
                    LoadAndSelect(value);
                }
            }
        }

        private static bool LoadDictionary(string value)
        {
            byte[] array = null;
            byte[] bytes = null;
            byte[] bytes2 = null;
            byte[] bytes3 = null;
            if (!localizationHasBeenSet)
            {
                if (loadFunction is null)
                {
                    string basePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Resources","ExcelOutputAsset");

                    string Local = File.ReadAllText($"{basePath}/Localization.txt");
                    array = Encoding.UTF8.GetBytes(Local);
                    string Local2 = File.ReadAllText($"{basePath}/ScenarioLocalization.txt");
                    bytes = Encoding.UTF8.GetBytes(Local2);
                    string Local3 = File.ReadAllText($"{basePath}/EventScenarioLocalization.txt");
                    bytes2 = Encoding.UTF8.GetBytes(Local3);
                    string Local4 = File.ReadAllText($"{basePath}/InfinityScenarioLocalization.txt");
                    bytes3 = Encoding.UTF8.GetBytes(Local4);
                }
                localizationHasBeenSet = true;
            }
            LoadCSV(bytes, merge: false, LocalizationType.Scenario);
            LoadCSV(bytes2, merge: false, LocalizationType.Event);
            LoadCSV(bytes3, merge: false, LocalizationType.Infinity);
            if (LoadCSV(array))
            {
                return true;
            }
            if (string.IsNullOrEmpty(value))
            {
                value = mLanguage;
            }
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            array = loadFunction(value);
            if (array is not null)
            {
                Set(value, array);
                return true;
            }
            return false;
        }

        private static bool LoadAndSelect(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (mDictionary.Count == 0 && !LoadDictionary(value))
                {
                    return false;
                }
                if (SelectLanguage(value))
                {
                    return true;
                }
            }
            if (mOldDictionary.Count > 0)
            {
                return true;
            }
            mOldDictionary.Clear();
            mDictionary.Clear();
            return false;
        }

        public static void Set(string languageName, byte[] bytes)
        {
            ByteReader byteReader = new(bytes);
            Set(languageName, byteReader.ReadDictionary());
        }

        public static bool LoadCSV(byte[] bytes, bool merge = false, LocalizationType type = LocalizationType.None)
        {
            return LoadCSV(bytes, null, merge, type);
        }

        private static bool HasLanguage(string languageName)
        {
            int i = 0;
            for (int num = mLanguages.Length; i < num; i++)
            {
                if (mLanguages[i] == languageName)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool LoadCSV(byte[] bytes, string asset, bool merge = false, LocalizationType type = LocalizationType.None)
        {
            if (bytes is null)
            {
                return false;
            }
            ByteReader byteReader = new(bytes);
            BetterList<string> betterList = byteReader.ReadCSV();
            if (betterList.size < 2)
            {
                return false;
            }
            betterList.RemoveAt(0);
            string[] array = null;
            if (string.IsNullOrEmpty(mLanguage))
            {
                localizationHasBeenSet = false;
            }
            if (!localizationHasBeenSet || !merge && !mMerging || mLanguages is null || mLanguages.Length == 0)
            {
                mDictionary.Clear();
                mLanguages = new string[betterList.size];
                if (!localizationHasBeenSet)
                {
                    mLanguage = betterList[0];
                    localizationHasBeenSet = true;
                }
                for (int i = 0; i < betterList.size; i++)
                {
                    mLanguages[i] = betterList[i];
                    if (mLanguages[i] == mLanguage)
                    {
                        mLanguageIndex = i;
                    }
                }
            }
            else
            {
                array = new string[betterList.size];
                for (int j = 0; j < betterList.size; j++)
                {
                    array[j] = betterList[j];
                }
                for (int k = 0; k < betterList.size; k++)
                {
                    if (HasLanguage(betterList[k]))
                    {
                        continue;
                    }
                    int num = mLanguages.Length + 1;
                    Array.Resize(ref mLanguages, num);
                    mLanguages[num - 1] = betterList[k];
                    Dictionary<string, string[]> dictionary = [];
                    foreach (KeyValuePair<string, string[]> item in mDictionary)
                    {
                        string[] array2 = item.Value;
                        Array.Resize(ref array2, num);
                        array2[num - 1] = array2[0];
                        dictionary.Add(item.Key, array2);
                    }
                    mDictionary = dictionary;
                }
            }
            Dictionary<string, int> dictionary2 = [];
            for (int l = 0; l < mLanguages.Length; l++)
            {
                dictionary2.Add(mLanguages[l], l);
            }
            while (true)
            {
                BetterList<string> betterList2 = byteReader.ReadCSV();
                if (betterList2 is null || betterList2.size == 0)
                {
                    break;
                }
                if (!string.IsNullOrEmpty(betterList2[0]))
                {
                    switch (type)
                    {
                        case LocalizationType.None:
                            AddCSV(betterList2, array, dictionary2);
                            break;

                        case LocalizationType.Scenario:
                            ScenarioAddCSV(betterList2, array, dictionary2);
                            break;

                        case LocalizationType.Event:
                            EventAddCSV(betterList2, array, dictionary2);
                            break;

                        case LocalizationType.Infinity:
                            InfinityAddCSV(betterList2, array, dictionary2);
                            break;
                    }
                }
            }
            if (!mMerging && onLocalize is not null)
            {
                mMerging = true;
                OnLocalizeNotification onLocalizeNotification = onLocalize;
                onLocalize = null;
                onLocalizeNotification();
                onLocalize = onLocalizeNotification;
                mMerging = false;
            }
            return true;
        }

        private static void AddCSV(BetterList<string> newValues, string[] newLanguages, Dictionary<string, int> languageIndices, bool isScenario = false)
        {
            if (newValues.size < 2)
            {
                return;
            }
            string text = newValues[0];
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            string[] value = ExtractStrings(newValues, newLanguages, languageIndices);
            if (mDictionary.ContainsKey(text))
            {
                mDictionary[text] = value;
                if (newLanguages is not null)
                {
                }
                return;
            }
            if (mTutorialDictionary.ContainsKey(text))
            {
                mTutorialDictionary[text] = value;
                if (newLanguages is not null)
                {
                }
                return;
            }
            if (mTalkDictionary.ContainsKey(text))
            {
                mTalkDictionary[text] = value;
                if (newLanguages is not null)
                {
                }
                return;
            }
            int num = int.Parse(text);
            if (num >= 50000 && num < 60000)
            {
                try
                {
                    mTutorialDictionary.Add(text, value);
                }
                catch (Exception)
                {
                }
            }
            if (num >= 60000 && num < 70000)
            {
                try
                {
                    mTalkDictionary.Add(text, value);
                    return;
                }
                catch (Exception)
                {
                    return;
                }
            }
            try
            {
                mDictionary.Add(text, value);
            }
            catch (Exception)
            {
            }
        }

        private static void ScenarioAddCSV(BetterList<string> newValues, string[] newLanguages, Dictionary<string, int> languageIndices)
        {
            if (newValues.size < 2)
            {
                return;
            }
            string text = newValues[0];
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            string[] value = ExtractStrings(newValues, newLanguages, languageIndices);
            if (mScenarioDictionary.ContainsKey(text))
            {
                mScenarioDictionary[text] = value;
                if (newLanguages is not null)
                {
                }
                return;
            }
            try
            {
                mScenarioDictionary.Add(text, value);
            }
            catch (Exception)
            {
            }
        }

        private static void EventAddCSV(BetterList<string> newValues, string[] newLanguages, Dictionary<string, int> languageIndices)
        {
            if (newValues.size < 2)
            {
                return;
            }
            string text = newValues[0];
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            string[] value = ExtractStrings(newValues, newLanguages, languageIndices);
            if (mEventDictionary.ContainsKey(text))
            {
                mEventDictionary[text] = value;
                if (newLanguages is not null)
                {
                }
                return;
            }
            try
            {
                mEventDictionary.Add(text, value);
            }
            catch (Exception)
            {
            }
        }

        private static void InfinityAddCSV(BetterList<string> newValues, string[] newLanguages, Dictionary<string, int> languageIndices)
        {
            if (newValues.size < 2)
            {
                return;
            }
            string text = newValues[0];
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            string[] value = ExtractStrings(newValues, newLanguages, languageIndices);
            if (mInfinityDictionary.ContainsKey(text))
            {
                mInfinityDictionary[text] = value;
                if (newLanguages is not null)
                {
                }
                return;
            }
            try
            {
                mInfinityDictionary.Add(text, value);
            }
            catch (Exception)
            {
            }
        }

        private static string[] ExtractStrings(BetterList<string> added, string[] newLanguages, Dictionary<string, int> languageIndices)
        {
            if (newLanguages is null)
            {
                string[] array = new string[mLanguages.Length];
                int i = 1;
                for (int num = (int)MathF.Min(added.size, array.Length + 1); i < num; i++)
                {
                    array[i - 1] = added[i];
                }
                return array;
            }
            string key = added[0];
            if (!mDictionary.TryGetValue(key, out var value))
            {
                value = new string[mLanguages.Length];
            }
            int j = 0;
            for (int num2 = newLanguages.Length; j < num2; j++)
            {
                string key2 = newLanguages[j];
                int num3 = languageIndices[key2];
                value[num3] = added[j + 1];
            }
            return value;
        }

        private static bool SelectLanguage(string language)
        {
            mLanguageIndex = -1;
            if (mDictionary.Count == 0)
            {
                return false;
            }
            int i = 0;
            for (int num = mLanguages.Length; i < num; i++)
            {
                if (mLanguages[i] == language)
                {
                    mOldDictionary.Clear();
                    mLanguageIndex = i;
                    mLanguage = language;
                    if (onLocalize is not null)
                    {
                        onLocalize();
                    }
                    return true;
                }
            }
            return false;
        }

        public static void Set(string languageName, Dictionary<string, string> dictionary)
        {
            mLanguage = languageName;
            mOldDictionary = dictionary;
            localizationHasBeenSet = true;
            mLanguageIndex = -1;
            mLanguages = [languageName];
            if (onLocalize is not null)
            {
                onLocalize();
            }
        }

        public static void Set(string key, string value)
        {
            if (mOldDictionary.ContainsKey(key))
            {
                mOldDictionary[key] = value;
            }
            else
            {
                mOldDictionary.Add(key, value);
            }
        }

        public static string Format(string key, params object[] parameters)
        {
            return string.Format(Get(key), parameters);
        }

        public static string Get(string key)
        {
            if (!localizationHasBeenSet)
            {
                LoadDictionary("S_En");
            }
            if (mLanguages is null)
            {
                return null;
            }
            string text = language;
            if (mLanguageIndex == -1)
            {
                for (int i = 0; i < mLanguages.Length; i++)
                {
                    if (mLanguages[i] == text)
                    {
                        mLanguageIndex = i;
                        break;
                    }
                }
            }
            if (mLanguageIndex == -1)
            {
                mLanguageIndex = 0;
                mLanguage = mLanguages[0];
            }
            string key2 = key + " Mobile";
            if (mLanguageIndex != -1 && mDictionary.TryGetValue(key2, out var value) && mLanguageIndex < value.Length)
            {
                return value[mLanguageIndex];
            }
            if (mOldDictionary.TryGetValue(key2, out var value2))
            {
                return value2;
            }
            if (mLanguageIndex != -1 && mDictionary.TryGetValue(key, out value))
            {
                if (mLanguageIndex < value.Length)
                {
                    string text2 = value[mLanguageIndex];
                    if (string.IsNullOrEmpty(text2))
                    {
                        text2 = value[0];
                    }
                    return text2;
                }
                return value[0];
            }
            if (mOldDictionary.TryGetValue(key, out value2))
            {
                return value2;
            }
            return key;
        }
    }
}