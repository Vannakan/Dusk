namespace Assets.Scripts.Action.Player
{
    public static class DirectionExtensionMethods
    {
        public static string GetStringValue(this Direction value)
        {
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());

            var attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attributes.Length > 0 ? attributes[0].StringValue : null;
        }

    }
}
