using Datory.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SSCMS.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaterialType
    {
        [DataEnum(DisplayName = "图文")] Message,
        [DataEnum(DisplayName = "图文")] Article,
        [DataEnum(DisplayName = "文字")] Text,
        [DataEnum(DisplayName = "图片")] Image,
        [DataEnum(DisplayName = "视频")] Video,
        [DataEnum(DisplayName = "音频")] Audio,
        [DataEnum(DisplayName = "文件")] File,
        [DataEnum(DisplayName = "组件")] Component
    }
}