// Copyright Information
// ==================================
// SoftwareTesting - MachineSpecifications - SetupTeardownAllContexts.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace MachineSpecifications.C_LifecycleOptions;

public class SetupTeardownAllContexts : IAssemblyContext
{
    public void OnAssemblyStart()
    {
        //Runs before all specs
        var foo = "foo";
    }

    public void OnAssemblyComplete()
    {
        //runs after all specs;
        var bar = "bar";
    }
}