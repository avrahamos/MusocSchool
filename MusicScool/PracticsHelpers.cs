internal static class PracticsHelpers
{
    static Func<List<string>, bool> IsEmpti = (list) => list.Any(item => item.StartsWith(""));
}