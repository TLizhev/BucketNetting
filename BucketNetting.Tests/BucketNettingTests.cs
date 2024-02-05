using System;
using BucketNetting.Model;
using BucketNetting.Services;
using FluentAssertions;
using Xunit;

namespace BucketNetting.Tests
{
    public class BucketNettingTests
    {
        private readonly AllocateToBucketService _sut = new();

        public static Portfolio SampleData = new()
        {
            DataDate = new DateTime(2024, 06, 30),
            Assets = new[]
            {
                new Asset {Id = "Equity1", Class = Class.Equity, MarketValue = 10000},
                new Asset {Id = "Future1", Class = Class.Future, MarketValue = 20000,  MaturityDate = new DateTime(2025, 12, 30)},
                new Asset {Id = "Equity2", Class = Class.Equity, MarketValue = 5000},
                new Asset {Id = "Future2", Class = Class.Future, MarketValue = -15000, MaturityDate = new DateTime(2024, 12, 30)},
                new Asset {Id = "Future3", Class = Class.Future, MarketValue = -30000, MaturityDate = new DateTime(2027, 12, 30)},
                new Asset {Id = "Future4", Class = Class.Future, MarketValue = 10000,  MaturityDate = new DateTime(2030, 12, 30)},
                new Asset {Id = "Future5", Class = Class.Future, MarketValue = 20000,  MaturityDate = new DateTime(2036, 12, 30)},
                new Asset {Id = "Equity3", Class = Class.Equity, MarketValue = 3000},
                new Asset {Id = "Future6", Class = Class.Future, MarketValue = 20000,  MaturityDate = new DateTime(2045, 12, 30)}
            }
        };

        [Fact]
        public void BucketNetting_ShouldWork()
        {
            // Arrange
            var data = new Portfolio
            {
                DataDate = new DateTime(2024, 06, 30),

                Assets = new[]
                {
                    new Asset
                    {
                        Id = "Future1", Class = Class.Future, MarketValue = 20000, MaturityDate = new DateTime(2028, 12, 30)
                    },
                    new()
                    {
                        Id = "Future1", Class = Class.Future, MarketValue = 20000, MaturityDate = new DateTime(2028, 12, 30)
                    },

                }
            };
            // Act

            var result = _sut.Allocate(data);
            var calculation = _sut.GetMarketValue(result);

            // Assert
            result[1].Assets.Count.Should().Be(2);
            calculation.Should().Be(40000);
        }
    }
}