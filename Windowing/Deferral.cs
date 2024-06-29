using System.Threading.Tasks;

namespace Gtudios.UI;
public class Deferral
{
    readonly TaskCompletionSource TaskCompletionSource = new();
    public Deferral() { }
    internal Task WaitAsync() => TaskCompletionSource.Task;
    public void Complete() => TaskCompletionSource.SetResult();
    public static Task WaitAsync(Deferral? deferral) => deferral is null ? Task.CompletedTask : deferral.WaitAsync();
}