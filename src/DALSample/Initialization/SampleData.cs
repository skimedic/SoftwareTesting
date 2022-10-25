// Copyright Information
// ==================================
// SoftwareTesting - DALSample - SampleData.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Initialization;

public static class SampleData
{
    public static List<Make> Makes => new()
    {
        new() { Id = 1, Name = "VW" },
        new() { Id = 2, Name = "Ford" },
        new() { Id = 3, Name = "Saab" },
        new() { Id = 4, Name = "Yugo" },
        new() { Id = 5, Name = "BMW" },
        new() { Id = 6, Name = "Pinto" },
    };

    public static List<Car> Inventory => new()
    {
        new() { Id = 1, MakeId = 1, Color = "Black", PetName = "Zippy" },
        new() { Id = 2, MakeId = 2, Color = "Rust", PetName = "Rusty" },
        new() { Id = 3, MakeId = 3, Color = "Black", PetName = "Mel" },
        new() { Id = 4, MakeId = 4, Color = "Yellow", PetName = "Clunker" },
        new() { Id = 5, MakeId = 5, Color = "Black", PetName = "Bimmer" },
        new() { Id = 6, MakeId = 5, Color = "Green", PetName = "Hank" },
        new() { Id = 7, MakeId = 5, Color = "Pink", PetName = "Pinky" },
        new() { Id = 8, MakeId = 6, Color = "Black", PetName = "Pete" },
        new() { Id = 9, MakeId = 4, Color = "Brown", PetName = "Brownie" },
        new() { Id = 10, MakeId = 1, Color = "Rust", PetName = "Lemon"}
    };
}
