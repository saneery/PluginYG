﻿using UnityEngine;
using UnityToolbag;

namespace YG
{
    [CreateAssetMenu(fileName = "YandexGameData", menuName = "InfoYG")]
    public class InfoYG : ScriptableObject
    {
        [Header("Basic Settings")]

        [Tooltip("При инициализации объекта Player авторизованному игроку будет показано диалоговое окно с запросом на предоставление доступа к персональным данным. Запрашивается доступ только к аватару и имени, идентификатор пользователя всегда передается автоматически. Примерное содержание: Игра запрашивает доступ к вашему аватару и имени пользователя на сервисах Яндекса.\nЕсли вам достаточно знать идентификатор, а имя и аватар пользователя не нужны, используйте опциональный параметр scopes: false. В этом случае диалоговое окно не будет показано.")]
        public bool scopes = true;

        public enum PlayerPhotoSize { small, medium, large };
        [ConditionallyVisible(nameof(scopes))]
        [Tooltip("Размер подкачанного изображения пользователя.")]
        public PlayerPhotoSize playerPhotoSize;

        [Tooltip("Вкл/Выкл лидерборды")]
        public bool leaderboardEnable;

        [Tooltip("Защита от кражи игры для публикации на пиратских сайтах.")]
        public bool siteLock = true;

        [Header("Ad")]

        [Tooltip("Защита от накруток вознаграждения при использовании рекламы за вознаграждение. Не даёт награду пользователям с AdBlock и другими аналогичными расширениями браузера. Пользователям, которые закрывают рекламу раньше времени. Предотвращает открытие нескольких рекламных блоков и соответственно получения чрезмерной награды.")]
        public bool checkAdblock = true;

        public enum FullscreenAdChallenge { atStartupAndSwitchScene, onlyAtStartup };
        [Tooltip("Выберите atStartupEndSwitchScene если хотите, чтобы полноэкранная реклама вызывалась при запуске игры и при переключении сцены. Выберите onlyAtStartup если хотите, чтобы реклама вызывалась только при запуске игры.")]
        public FullscreenAdChallenge fullscreenAdChallenge;

        [Tooltip("Если данный параметр выключен, то статические баннеры будут отображаться только во время загрузки игры. Если данный параметр включен, то статические баннеры будут отображаться и во время загрузки игры и в самой игре они тоже будут присутствовать!")]
        public bool staticRBTInGame;

        [Header("Language Translation")]

        [Tooltip("Вкл/Выкл локализацию с помощью плагина.")]
        public bool LocalizationEnable;

        public enum CallingLanguageCheck { FirstLaunchOnly, EveryGameLaunch, DoNotChangeLanguageStartup };
        [Tooltip("Менять язык игры в соответствии с языком браузера:\nFirstLaunchOnly - Только при первом запуске игры\nEveryGameLaunch - Каждый раз при запуске игры\nDoNotChangeLanguageStartup - Не менять язык при запуске игры.")]
        [ConditionallyVisible(nameof(LocalizationEnable))]
        public CallingLanguageCheck callingLanguageCheck;

        public enum TranslateMethod { AutoLocalization, Manual, CSVFile };
        [Tooltip("Метод перевода. \nAutoLocalization - Автоматический перевод через интернет с помощью Google Translate \nManual - Ручной режим. Вы сами записываете перевод в компоненте LanguageYG \nCSVFile - Перевод с плмлщью Excel файла.")]
        [ConditionallyVisible(nameof(LocalizationEnable))]
        public TranslateMethod translateMethod;

        [System.Serializable]
        public class CSVTranslate
        {
            public enum FileFormat { GoogleSheets, ExcelOffice };
            [Tooltip("Формат scv файла. \nGoogleSheets - Создаст файл с разделительной запятой (,) \nExcelOffice - Создаст файл с разделительной точкой с запятой (;).")]
            [ConditionallyVisible(nameof(LocalizationEnable))]
            public FileFormat format;

            [Tooltip("Имя CSV файла.")]
            [ConditionallyVisible(nameof(LocalizationEnable))]
            public string name = "TranslateCSV";
        }
        [ConditionallyVisible(nameof(LocalizationEnable))]
        [Tooltip("Настройки для метода локализации с помощью CSV файла. Это подразоумивает перевод по ключам всех текстов игры в таблице Excel или Google Sheets.")]
        public CSVTranslate CSVFileTranslate;

        #region LanguagesEnumeration
        [System.Serializable]
        public class Languages
        { 
            [Tooltip("RUSSIAN")] public bool ru;
            [Tooltip("ENGLISH")] public bool en;
            [Tooltip("TURKISH")] public bool tr;
            [Tooltip("AZERBAIJANIAN")] public bool az;
            [Tooltip("BELARUSIAN")] public bool be;
            [Tooltip("HEBREW")] public bool he;
            [Tooltip("ARMENIAN")] public bool hy;
            [Tooltip("GEORGIAN")] public bool ka;
            [Tooltip("ESTONIAN")] public bool et;
            [Tooltip("FRENCH")] public bool fr;
            [Tooltip("KAZAKH")] public bool kk;
            [Tooltip("KYRGYZ")] public bool ky;
            [Tooltip("LITHUANIAN")] public bool lt;
            [Tooltip("LATVIAN")] public bool lv;
            [Tooltip("ROMANIAN")] public bool ro;
            [Tooltip("TAJICK")] public bool tg;
            [Tooltip("TURKMEN")] public bool tk;
            [Tooltip("UKRAINIAN")] public bool uk;
            [Tooltip("UZBEK")] public bool uz;
            [Tooltip("SPANISH")] public bool es;
            [Tooltip("PORTUGUESE")] public bool pt;
            [Tooltip("ARABAIN")] public bool ar;
            [Tooltip("INDONESIAN")] public bool id;
            [Tooltip("JAPANESE")] public bool ja;
            [Tooltip("ITALIAN")] public bool it;
            [Tooltip("GERMAN")] public bool de;
            [Tooltip("HINDI")] public bool hi;
        }

        [ConditionallyVisible(nameof(LocalizationEnable))]
        [Tooltip("Выберите языки, на которые будет переведена Ваша игра.")]
        public Languages languages;

        [System.Serializable]
        public class Fonts
        {
            [Tooltip("Стандартный шрифт")] public Font[] defaultFont;
            [Tooltip("RUSSIAN")] public Font[] ru;
            [Tooltip("ENGLISH")] public Font[] en;
            [Tooltip("TURKISH")] public Font[] tr;
            [Tooltip("AZERBAIJANIAN")] public Font[] az;
            [Tooltip("BELARUSIAN")] public Font[] be;
            [Tooltip("HEBREW")] public Font[] he;
            [Tooltip("ARMENIAN")] public Font[] hy;
            [Tooltip("GEORGIAN")] public Font[] ka;
            [Tooltip("ESTONIAN")] public Font[] et;
            [Tooltip("FRENCH")] public Font[] fr;
            [Tooltip("KAZAKH")] public Font[] kk;
            [Tooltip("KYRGYZ")] public Font[] ky;
            [Tooltip("LITHUANIAN")] public Font[] lt;
            [Tooltip("LATVIAN")] public Font[] lv;
            [Tooltip("ROMANIAN")] public Font[] ro;
            [Tooltip("TAJICK")] public Font[] tg;
            [Tooltip("TURKMEN")] public Font[] tk;
            [Tooltip("UKRAINIAN")] public Font[] uk;
            [Tooltip("UZBEK")] public Font[] uz;
            [Tooltip("SPANISH")] public Font[] es;
            [Tooltip("PORTUGUESE")] public Font[] pt;
            [Tooltip("ARABAIN")] public Font[] ar;
            [Tooltip("INDONESIAN")] public Font[] id;
            [Tooltip("JAPANESE")] public Font[] ja;
            [Tooltip("ITALIAN")] public Font[] it;
            [Tooltip("GERMAN")] public Font[] de;
            [Tooltip("HINDI")] public Font[] hi;
        }

        [ConditionallyVisible(nameof(LocalizationEnable))]
        [Tooltip("Здесь вы можете выбрать одельные шрифты для каждого языка.")]
        public Fonts fonts;
        #endregion LanguagesEnumeration

        [Header("Other")]

        [Tooltip("Для более старых версий Unity требуется задержка старта SDK (задержка в кардах в секунду).\nСтавить задержку сдедует, если при запуске игры на Web сервере, после загрузки игры происходит краш или функции SDK не работают. В таком случае, обновите Unity до актуальной версии, либо поставьте задержку (рекомедруется: 20).\nЕсли SDK умпешно загружается, задержку ставить не требуется.")]
        [Min(0)]
        public int SDKStartDelay;

        [Tooltip("Вы можете выключить запись лога в консоль.")]
        public bool debug = true;



        public bool[] LangArr()
        {
            bool[] b = new bool[27];

            b[0] = languages.ru;
            b[1] = languages.en;
            b[2] = languages.tr;
            b[3] = languages.az;
            b[4] = languages.be;
            b[5] = languages.he;
            b[6] = languages.hy;
            b[7] = languages.ka;
            b[8] = languages.et;
            b[9] = languages.fr;
            b[10] = languages.kk;
            b[11] = languages.ky;
            b[12] = languages.lt;
            b[13] = languages.lv;
            b[14] = languages.ro;
            b[15] = languages.tg;
            b[16] = languages.tk;
            b[17] = languages.uk;
            b[18] = languages.uz;
            b[19] = languages.es;
            b[20] = languages.pt;
            b[21] = languages.ar;
            b[22] = languages.id;
            b[23] = languages.ja;
            b[24] = languages.it;
            b[25] = languages.de;
            b[26] = languages.hi;

            return b;
        }

        public string LangName(int i)
        {
            if (i == 0) return "ru";
            else if (i == 1) return "en";
            else if (i == 2) return "tr";
            else if (i == 3) return "az";
            else if (i == 4) return "be";
            else if (i == 5) return "he";
            else if (i == 6) return "hy";
            else if (i == 7) return "ka";
            else if (i == 8) return "et";
            else if (i == 9) return "fr";
            else if (i == 10) return "kk";
            else if (i == 11) return "ky";
            else if (i == 12) return "lt";
            else if (i == 13) return "lv";
            else if (i == 14) return "ro";
            else if (i == 15) return "tg";
            else if (i == 16) return "tk";
            else if (i == 17) return "uk";
            else if (i == 18) return "uz";
            else if (i == 19) return "es";
            else if (i == 20) return "pt";
            else if (i == 21) return "ar";
            else if (i == 22) return "id";
            else if (i == 23) return "ja";
            else if (i == 24) return "it";
            else if (i == 25) return "de";
            else if (i == 26) return "hi";
            else return null;
        }

        public Font[] GetFont(int i)
        {
            if (i == 0) return fonts.ru;
            else if (i == 1) return fonts.en;
            else if (i == 2) return fonts.tr;
            else if (i == 3) return fonts.az;
            else if (i == 4) return fonts.be;
            else if (i == 5) return fonts.he;
            else if (i == 6) return fonts.hy;
            else if (i == 7) return fonts.ka;
            else if (i == 8) return fonts.et;
            else if (i == 9) return fonts.fr;
            else if (i == 10) return fonts.kk;
            else if (i == 11) return fonts.ky;
            else if (i == 12) return fonts.lt;
            else if (i == 13) return fonts.lv;
            else if (i == 14) return fonts.ro;
            else if (i == 15) return fonts.tg;
            else if (i == 16) return fonts.tk;
            else if (i == 17) return fonts.uk;
            else if (i == 18) return fonts.uz;
            else if (i == 19) return fonts.es;
            else if (i == 20) return fonts.pt;
            else if (i == 21) return fonts.ar;
            else if (i == 22) return fonts.id;
            else if (i == 23) return fonts.ja;
            else if (i == 24) return fonts.it;
            else if (i == 25) return fonts.de;
            else if (i == 26) return fonts.hi;
            else return null;
        }
    }
}
