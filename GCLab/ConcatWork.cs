namespace GCLab;

// ===================================
// 4) Concatenação de string ineficiente
// ===================================
static class ConcatWork
{
    public static string Bad()
    {
        var sb = new System.Text.StringBuilder(capacity: 50_000 * 2);
        for (int i = 0; i < 50_000; i++)
            sb.Append(i);
        return sb.ToString();
    }    
}
