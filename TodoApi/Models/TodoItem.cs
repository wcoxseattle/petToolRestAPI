﻿namespace TodoApi.Models
{
    public class TodoItem
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
}
