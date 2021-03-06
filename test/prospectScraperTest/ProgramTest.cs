﻿using prospectScraper;
using System;
using Xunit;

namespace prospectScraperTest
{
    public class ProgramTest
    {
        private const string InvalidDateString = "TEST";
        private const string ValidDateString = "May 21, 2019 2:00 AM";

        [Theory]
        [InlineData(73, "6'1")]
        [InlineData(12, "1'0")]
        public void Converts_Height_To_Inches(int expectedHeightInInches, string heightInFt)
        {
            //Act
            int actual = Player.ConvertHeightToInches(heightInFt, "FOO");

            //Assert
            Assert.Equal(expectedHeightInInches, actual);
        }

        [Fact]
        public void Draft_Date_Defaults_To_Today()
        {
            //Arrange
            string expected = DateTime.Now.ToString("yyyy-MM-dd");

            string actual = ProspectScraper.ChangeDateStringToDateTime(InvalidDateString, true).ToString("yyyy-MM-dd");

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Formats_Draft_Date()
        {
            //Arrange
            string expected = "2019-05-21";

            string actual = ProspectScraper.ChangeDateStringToDateTime(ValidDateString, true).ToString("yyyy-MM-dd");

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Schools_Returns_Unmodified()
        {
            //Assert
            Assert.Equal("hogWarts", School.CheckSchool("hogWarts"));
        }

        [Theory]
        [InlineData("Miami", "Miami (FL)")]
        [InlineData("North Carolina State", "NC State")]
        public void Valid_Schools(string input, string expected)
        {
            //Act
            string actual = School.CheckSchool(input);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
