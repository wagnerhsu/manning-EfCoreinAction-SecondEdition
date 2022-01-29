// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Many2Many;

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }

    public ICollection<BookAuthor> BooksLink { get; set; } //#F
}
