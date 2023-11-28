using DevExtreme.AspNet.Mvc;

namespace HRM_DevEpress.Common
{
    public static class UICommonConsts
    {
        public const int GRID_PAGE_SIZE_DEFAULT = 50;
        public const int GRID_PAGE_SIZE_MEDIUM_DEFAULT = 100;
        public const int GRID_PAGE_SIZE_MAX_DEFAULT = 300;
        public const int GRID_PAGE_SIZE_MIN_DEFAULT = 10;
        public const string GRID_HEIGHT_DEFAULT = "calc(100vh - 244px)";
        public const string GRID_HEIGHT_CUSTOM = "calc(100vh - 276px)";
        public static readonly JS GRID_ALLOWED_PAGE_SIZES = new JS("[10, 50, 100, 200, 300]");
    }


}
