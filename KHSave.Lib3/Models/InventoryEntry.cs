/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using Xe.BinaryMapper;

namespace KHSave.Lib3.Models
{
    public class InventoryEntry
    {
        [Data] public byte Count { get; set; }
        [Data] public bool Obtained { get; set; }
        [Data] public bool Unseen { get; set; }
        [Data] public bool ShopFlag1 { get; set; }
        [Data] public bool ShopFlag2 { get; set; }
        [Data] public bool Flag4 { get; set; }
        [Data] public bool Flag5 { get; set; }
        [Data] public bool Flag6 { get; set; }
        [Data] public bool Flag7 { get; set; }
    }
}
