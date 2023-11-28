using DevExtreme.AspNet.Data.ResponseModel;

namespace HRM_DevEpress.Common
{
    public static class DevExpressHelper
    {
        public static LoadResult ConvertToLoadResult<T>(this List<T> items, int totalCount = -1)
        {
            if (items == null)
            {
                return new LoadResult();
            }
            var result = new LoadResult { data = items, totalCount = totalCount <= -1 ? items.Count : totalCount };
            return result;
        }
    }
}
