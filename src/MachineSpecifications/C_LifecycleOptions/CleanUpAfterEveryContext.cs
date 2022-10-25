// Copyright Information
// ==================================
// SoftwareTesting - MachineSpecifications - CleanUpAfterEveryContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace MachineSpecifications.C_LifecycleOptions;

public class CleanUpAfterEveryContext : ICleanupAfterEveryContextInAssembly
{
    public void AfterContextCleanup()
    {
        //Runs after every context in assembly 
        //eliminates need for repeated code in Cleanup 
        var foobar = "foobar";
    }
}