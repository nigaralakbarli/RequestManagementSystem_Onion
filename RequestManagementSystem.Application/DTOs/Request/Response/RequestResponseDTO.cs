﻿namespace RequestManagementSystem.Application.DTOs.Request.Response;

public class RequestResponseDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string CreateUser { get; set; }
    public string ExecutorUser { get; set; }
    public string Priority { get; set; }
    public string RequestStatus { get; set; }
    public DateTime CreateAt { get; set; }
    public string RequestType { get; set; }
}
