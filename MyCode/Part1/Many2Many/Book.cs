// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Many2Many;

public class Book
{
    public int BookId { get; set; }
    public ICollection<Tag> Tags { get; set; } //#E

    public ICollection<BookAuthor> AuthorsLink { get; set; } //#F
}
