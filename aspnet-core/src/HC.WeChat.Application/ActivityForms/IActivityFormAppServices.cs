﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HC.WeChat.ActivityForms.Dtos;
using HC.WeChat.ActivityForms;
using System;
using HC.WeChat.Dto;

namespace HC.WeChat.ActivityForms
{
    /// <summary>
    /// ActivityForm应用层服务的接口方法
    /// </summary>
    public interface IActivityFormAppService : IApplicationService
    {
        /// <summary>
        /// 获取ActivityForm的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ActivityFormListDto>> GetPagedActivityForms(GetActivityFormsInput input);

        /// <summary>
        /// 通过指定id获取ActivityFormListDto信息
        /// </summary>
        Task<ActivityFormListDto> GetActivityFormByIdAsync(EntityDto<Guid> input);

        /// <summary>
        /// 导出ActivityForm为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetActivityFormsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetActivityFormForEditOutput> GetActivityFormForEdit(NullableIdDto<Guid> input);

        //todo:缺少Dto的生成GetActivityFormForEditOutput
        /// <summary>
        /// 添加或者修改ActivityForm的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateActivityForm(CreateOrUpdateActivityFormInput input);

        /// <summary>
        /// 删除ActivityForm信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteActivityForm(EntityDto<Guid> input);

        /// <summary>
        /// 批量删除ActivityForm
        /// </summary>
        Task BatchDeleteActivityFormsAsync(List<Guid> input);

        Task<APIResultDto> SubmitActivityFormAsync(ActivityFormInputDto input);
    }
}
