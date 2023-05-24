using AutoMapper;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Category.Response;
using RequestManagementSystem.Application.DTOs.Comment.Request;
using RequestManagementSystem.Application.DTOs.Comment.Response;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.DTOs.Department.Response;
using RequestManagementSystem.Application.DTOs.Priority.Request;
using RequestManagementSystem.Application.DTOs.Priority.Response;
using RequestManagementSystem.Application.DTOs.Report.Response;
using RequestManagementSystem.Application.DTOs.Request.Request;
using RequestManagementSystem.Application.DTOs.Request.Response;
using RequestManagementSystem.Application.DTOs.RequestDetail.Request;
using RequestManagementSystem.Application.DTOs.RequestDetail.Response;
using RequestManagementSystem.Application.DTOs.RequestStatus.Request;
using RequestManagementSystem.Application.DTOs.RequestStatus.Response;
using RequestManagementSystem.Application.DTOs.RequestType.Request;
using RequestManagementSystem.Application.DTOs.RequestType.Response;
using RequestManagementSystem.Application.DTOs.User.Request;
using RequestManagementSystem.Application.DTOs.User.Response;
using RequestManagementSystem.Application.Helper.HistoryDescriptions;
using RequestManagementSystem.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RequestManagementSystem.Application.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<CategoryRequestDTO, Category>();

            CreateMap<CommentRequestDTO, Comment>();
            CreateMap<Comment, CommentResponseDTO>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.User.Position));


            CreateMap<RequestDetailUpdateDTO, RequestDetail>();
            CreateMap<RequestDetail, RequestDetailResponseDTO>();

            CreateMap<UserCategoryCreateDTO, UserCategory>();


            CreateMap<Department, DepartmentResponseDTO>();
            CreateMap<DepartmentRequestDTO, Department>();

            CreateMap<RequestChangeStatusDTO, Request>();

            CreateMap<Priority, PriorityResponseDTO>();
            CreateMap<PriorityRequestDTO, Priority>();




            CreateMap<Request, RequestResponseDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.Level))
                .ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => src.RequestType.Name))
                .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src => src.RequestStatus.Name))
                .ForMember(dest => dest.CreateUser, opt => opt.MapFrom(src => src.CreateUser.Name))
                .ForMember(dest => dest.ExecutorUser, opt => opt.MapFrom(src => src.ExecutorUser.Name));
            CreateMap<RequestCreateDTO, Request>();

            CreateMap<Domain.Entities.Action, RequestHistoryDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.User.Position))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => GetHistoryDescription(src.RequestStatusId)))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt));


            CreateMap<Report, ReportResponseDTO>()
                .ForMember(dest => dest.CreateUser, opt => opt.MapFrom(src => src.Request.CreateUser.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Request.Category.Name))
                .ForMember(dest => dest.ExecutorUser, opt => opt.MapFrom(src => src.Request.ExecutorUser.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Request.RequestStatus.Name));


            CreateMap<RequestStatus, RequestStatusResponseDTO>();
            CreateMap<RequestStatusRequestDTO, RequestStatus>();

            CreateMap<RequestType, RequestTypeResponseDTO>();
            CreateMap<RequestTypeRequestDTO, RequestType>();

            CreateMap<User, UserResponseDTO>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>().ForMember(y => y.Name, y => y.Ignore());

        }

        private static string GetHistoryDescription(int statusId)
        {
            string desc = statusId switch
            {
                1 => HistoryDescription.open,
                2 => HistoryDescription.inExecution,
                4 => HistoryDescription.waiting,
                6 => HistoryDescription.close,
                _ => string.Empty
            };
            return desc;
        }
    }
}
