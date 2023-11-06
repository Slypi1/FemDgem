public static class StringUtils
{
    public static string NicknameString(this string nickName) => string.Format("Позывной: {0}", nickName);
    public static string AgeString(this int age) => string.Format("Возраст: {0}", age);
    public static string FamilyStatusString(this string status) => string.Format("Семейное положение: {0}", status);
    public static string AccessLevelString(this string access) => string.Format("Уровень допуска: {0}", access);
    public static string JobPositionString(this string position) => string.Format("Должность: {0}", position);
    public static string OccupationString(this string occupation) => string.Format("Род деятельности: {0}", occupation);
}
