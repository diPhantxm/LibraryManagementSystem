using LibraryManagementSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.DAL.Models
{
    public class BookDimensions : IEntity
    {
        public int Id { get; set; }

        public float Length { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }

        public virtual Book Book { get; set; }


        public BookDimensions(float length, float width, float height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public BookDimensions()
        {

        }

        public override string ToString()
        {
            return String.Format($"{ Length }x{ Width }x{ Height }");
        }
    }
}
