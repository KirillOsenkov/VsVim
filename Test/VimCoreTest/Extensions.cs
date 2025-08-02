using System.Threading;
using Microsoft.VisualStudio.Text.Tagging;
using Vim.Extensions;
using Vim.UnitTest;

namespace Vim.EditorHost
{
    /// <summary>
    /// Contains extension methods common to all unit test
    /// </summary>
    public static partial class Extensions
    {
        internal static void WaitForBackgroundToComplete<TData, TTag>(this AsyncTagger<TData, TTag> asyncTagger, TestableSynchronizationContext synchronizationContext)
            where TTag : ITag
        {
            while (asyncTagger.AsyncBackgroundRequestData.IsSome())
            {
                synchronizationContext.RunAll();
                Thread.Yield();
            }
        }
    }
}