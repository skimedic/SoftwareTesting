// Copyright Information
// ==================================
// SoftwareTesting - DALIntegrationTests - EnsureAutoLotDatabaseTestFixture.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALIntegrationTests.Base;

public sealed class EnsureAutoLotDatabaseTestFixture : IDisposable
{
    public EnsureAutoLotDatabaseTestFixture()
    {
        var configuration = TestHelpers.GetConfiguration();
        var context = TestHelpers.GetContext(configuration);
        SampleDataInitializer.ClearAndReseedDatabase(context);
        context.Dispose();
    }

    public void Dispose()
    {
    }
}
