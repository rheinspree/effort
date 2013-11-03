﻿// --------------------------------------------------------------------------------------------
// <copyright file="StringFunctionsFixture.cs" company="Effort Team">
//     Copyright (C) 2011-2013 Effort Team
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in
//     all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//     THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------

namespace Effort.Test.Features.CanonicalFunctions
{
    using System.Linq;
    using Effort.Test.Data.Features;
    using Effort.Test.Data.Northwind;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftwareApproach.TestingExtensions;
#if !EFOLD
    using System.Data.Entity;
#else
    using System.Data.Objects;
#endif

    [TestClass]
    public class StringFunctionsFixture
    {
        private FeatureDbContext context;

        [TestInitialize]
        public void Initialize()
        {
            this.context =
                new FeatureDbContext(
                    DbConnectionFactory.CreateTransient(),
                    CompiledModels.GetModel<StringFieldEntity>());
        }

         [TestMethod]
        public void StringConcat()
        {
            this.context.StringFieldEntities.Add(new StringFieldEntity { Value = "data" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Select(x => 
                    string.Concat(x.Value, "1"));

            var res = q.ToList();
            res.Any(x => x == "data1").ShouldBeTrue();
        }

         [TestMethod]
         public void StringConcatNull()
         {
             this.context.StringFieldEntities.Add(new StringFieldEntity { Value = null });
             this.context.SaveChanges();

             var q = this.context
                 .StringFieldEntities
                 .Select(x =>
                     string.Concat(x.Value, "1"));

             var res = q.ToList();
             res.Any(x => x == null).ShouldBeTrue();
         }

        [TestMethod]
        public void StringIsNullOrEmpty()
        {
            this.context.StringFieldEntities.Add(new StringFieldEntity { Value = "" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    string.IsNullOrEmpty(x.Value));

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringIsNullOrEmptyNull()
        {
            this.context.StringFieldEntities.Add(new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    string.IsNullOrEmpty(x.Value));

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringContains()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "apple orange banana" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Contains("banana"));

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringEndsWith()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.EndsWith("ge"));

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringStartsWith()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.StartsWith("or"));

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringLength()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Length == 6);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringLengthNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Length == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringIndexOf()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.IndexOf("ra") == 1);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringIndexOf2()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.IndexOf("app") == -1);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringIndexOfNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.IndexOf(null) == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringIndexOfNull2()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.IndexOf("a") == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringInsert()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Insert(1, "123") == "o123range");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringInsertNull1()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Insert(1, "123") == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringInsertNull2()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Insert(1, null) == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringRemove1()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Remove(3) == "ora");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringRemove2()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Remove(3, 2) == "orae");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringReplace()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Replace("nge", "cle") == "oracle");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringReplaceNull1()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Replace("nge", "cle") == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringReplaceNull2()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Replace(null, "cle") == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringReplaceNull3()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Replace("nge", null) == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringSubstring1()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Substring(3) == "nge");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringSubstring2()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Substring(3, 2) == "ng");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringSubstringNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Substring(3, 2) == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringToLower()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "OraNge" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.ToLower() == "orange");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringToLowerNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.ToLower() == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringToUpper()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "OraNge" });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.ToUpper() == "ORANGE");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringToUpperNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.ToUpper() == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Trim()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = " orange  " });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Trim() == "orange");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void TrimNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.Trim() == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void TrimEnd()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = " orange  " });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.TrimEnd() == " orange");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void TrimEndNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.TrimEnd() == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void TrimStart()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = " orange  " });
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.TrimStart() == "orange  ");

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void TrimStartNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null});
            this.context.SaveChanges();

            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    x.Value.TrimStart() == null);

            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringReverse()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = "orange" });
            this.context.SaveChanges();

#if !EFOLD
            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    DbFunctions.Reverse(x.Value) == "egnaro");
#else
            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    EntityFunctions.Reverse(x.Value) == "egnaro");
#endif
            q.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void StringReverseNull()
        {
            this.context.StringFieldEntities.Add(
                new StringFieldEntity { Value = null });
            this.context.SaveChanges();

#if !EFOLD
            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    DbFunctions.Reverse(x.Value) == null);
#else
            var q = this.context
                .StringFieldEntities
                .Where(x =>
                    EntityFunctions.Reverse(x.Value) == null);
#endif
            q.ShouldNotBeEmpty();
        }
    }
}
