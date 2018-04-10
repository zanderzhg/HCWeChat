﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using HC.WeChat.ActivityBanquets.Authorization;
using HC.WeChat.ActivityBanquets.Dtos;
using HC.WeChat.ActivityBanquets.DomainServices;
using HC.WeChat.ActivityBanquets;
using System;
using System.Linq;
using HC.WeChat.Authorization;
using HC.WeChat.Authorization.Users;
using HC.WeChat.Dto;
using HC.WeChat.ActivityDeliveryInfos;
using HC.WeChat.WeChatUsers.DomainServices;
using HC.WeChat.WechatEnums;
using HC.WeChat.ActivityForms;
using HC.WeChat.ActivityFormLogs;

namespace HC.WeChat.ActivityBanquets
{
    /// <summary>
    /// ActivityBanquet应用层服务的接口实现方法
    /// </summary>
    //[AbpAuthorize(ActivityBanquetAppPermissions.ActivityBanquet)]
    [AbpAuthorize(AppPermissions.Pages)]
    public class ActivityBanquetAppService : WeChatAppServiceBase, IActivityBanquetAppService
    {
        private readonly IRepository<ActivityBanquet, Guid> _activitybanquetRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IActivityBanquetManager _activitybanquetManager;
        private readonly IWeChatUserManager _wechatuserManager;
        private readonly IRepository<ActivityForm, Guid> _activityFormRepository;
        private readonly IRepository<ActivityFormLog, Guid> _activityFormLogRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ActivityBanquetAppService(IRepository<ActivityBanquet, Guid> activitybanquetRepository
        , IActivityBanquetManager activitybanquetManager
        , IRepository<User, long> userRepository
        , IWeChatUserManager wechatuserManager
        , IRepository<ActivityForm, Guid> activityFormRepository
        , IRepository<ActivityFormLog, Guid> activityFormLogRepository
        )
        {
            _activitybanquetRepository = activitybanquetRepository;
            _activitybanquetManager = activitybanquetManager;
            _userRepository = userRepository;
            _wechatuserManager = wechatuserManager;
            _activityFormRepository = activityFormRepository;
            _activityFormLogRepository = activityFormLogRepository;
        }

        /// <summary>
        /// 获取ActivityBanquet的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<ActivityBanquetListDto>> GetPagedActivityBanquets(GetActivityBanquetsInput input)
        {

            var query = _activitybanquetRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var activitybanquetCount = await query.CountAsync();

            var activitybanquets = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            //var activitybanquetListDtos = ObjectMapper.Map<List <ActivityBanquetListDto>>(activitybanquets);
            var activitybanquetListDtos = activitybanquets.MapTo<List<ActivityBanquetListDto>>();

            return new PagedResultDto<ActivityBanquetListDto>(
                activitybanquetCount,
                activitybanquetListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取ActivityBanquetListDto信息
        /// </summary>
        public async Task<ActivityBanquetListDto> GetActivityBanquetByIdAsync(EntityDto<Guid> input)
        {
            var entity = await _activitybanquetRepository.GetAsync(input.Id);

            return entity.MapTo<ActivityBanquetListDto>();
        }

        public async Task<ActivityBanquetListDto> GetActivityBanquetByFormIdAsync(EntityDto<Guid> input)
        {
            var entity = await _activitybanquetRepository.GetAll().Where(a => a.ActivityFormId == input.Id).FirstOrDefaultAsync();

            return entity.MapTo<ActivityBanquetListDto>();
        }

        /// <summary>
        /// 导出ActivityBanquet为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetActivityBanquetsToExcel(){
        //var users = await UserManager.Users.ToListAsync();
        //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //await FillRoleNames(userListDtos);
        //return _userListExcelExporter.ExportToFile(userListDtos);
        //}
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetActivityBanquetForEditOutput> GetActivityBanquetForEdit(NullableIdDto<Guid> input)
        {
            var output = new GetActivityBanquetForEditOutput();
            ActivityBanquetEditDto activitybanquetEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _activitybanquetRepository.GetAsync(input.Id.Value);

                activitybanquetEditDto = entity.MapTo<ActivityBanquetEditDto>();

                //activitybanquetEditDto = ObjectMapper.Map<List <activitybanquetEditDto>>(entity);
            }
            else
            {
                activitybanquetEditDto = new ActivityBanquetEditDto();
            }

            output.ActivityBanquet = activitybanquetEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改ActivityBanquet的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateActivityBanquet(CreateOrUpdateActivityBanquetInput input)
        {
            if (input.ActivityBanquet.Id.HasValue)
            {
                await UpdateActivityBanquetAsync(input.ActivityBanquet);
            }
            else
            {
                var user = await _userRepository.GetAsync(AbpSession.UserId.Value);
                input.ActivityBanquet.UserName = user.Name;
                await CreateActivityBanquetAsync(input.ActivityBanquet);
            }
        }

        /// <summary>
        /// 新增ActivityBanquet
        /// </summary>
        //[AbpAuthorize(ActivityBanquetAppPermissions.ActivityBanquet_CreateActivityBanquet)]
        protected virtual async Task<ActivityBanquetEditDto> CreateActivityBanquetAsync(ActivityBanquetEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<ActivityBanquet>(input);

            entity = await _activitybanquetRepository.InsertAsync(entity);
            return entity.MapTo<ActivityBanquetEditDto>();
        }

        /// <summary>
        /// 编辑ActivityBanquet
        /// </summary>
        //[AbpAuthorize(ActivityBanquetAppPermissions.ActivityBanquet_EditActivityBanquet)]
        protected virtual async Task UpdateActivityBanquetAsync(ActivityBanquetEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _activitybanquetRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _activitybanquetRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除ActivityBanquet信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(ActivityBanquetAppPermissions.ActivityBanquet_DeleteActivityBanquet)]
        public async Task DeleteActivityBanquet(EntityDto<Guid> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _activitybanquetRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除ActivityBanquet的方法
        /// </summary>
        //[AbpAuthorize(ActivityBanquetAppPermissions.ActivityBanquet_BatchDeleteActivityBanquets)]
        public async Task BatchDeleteActivityBanquetsAsync(List<Guid> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _activitybanquetRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        [AbpAllowAnonymous]
        public async Task<APIResultDto> SubmitActivityBanquetWeChatAsync(ActivityBanquetWeChatDto input)
        {
            var banquest = input.MapTo<ActivityBanquet>();
            var delivery = input.MapTo<ActivityDeliveryInfo>();//收货信息

            var user = await _wechatuserManager.GetWeChatUserAsync(input.OpenId, input.TenantId);

            if (user == null)
            {
                return new APIResultDto() { Code = 701, Msg = "当前用户无效" };
            }

            if (user.UserType != UserTypeEnum.零售客户 && user.UserType != UserTypeEnum.客户经理)
            {
                return new APIResultDto() { Code = 702, Msg = "当前用户类型不支持" };
            }

            using (CurrentUnitOfWork.SetTenantId(input.TenantId))
            {
                var activityForm = await _activityFormRepository.GetAsync(input.ActivityFormId);
                if (user.UserType == UserTypeEnum.零售客户)
                {
                    banquest.Responsible = activityForm.ManagerName;
                    banquest.Executor = activityForm.RetailerName;
                }
                else//客户经理更新状态
                {
                    activityForm.Status = FormStatusEnum.资料回传已审核;
                    //记录审核日志
                    var log = new ActivityFormLog();
                    log.ActionTime = DateTime.Now;
                    log.ActivityFormId = activityForm.Id;
                    log.Opinion = activityForm.Status.ToString();
                    log.Status = activityForm.Status;
                    log.StatusName = activityForm.Status.ToString();
                    log.UserId = user.Id;
                    log.UserName = user.UserName;

                    await _activityFormRepository.UpdateAsync(activityForm);
                    await _activityFormLogRepository.InsertAsync(log);

                    banquest.Responsible = activityForm.ManagerName;
                    banquest.Executor = activityForm.ManagerName;
                }

                banquest.UserName = user.UserName;
                banquest.CreationTime = DateTime.Now;

                await _activitybanquetRepository.InsertAsync(banquest);
            }

            if (user.UserType == UserTypeEnum.零售客户)
            {
                return new APIResultDto() { Code = 0, Msg = "资料提交成功，待客户经理审核" };
            }
            else
            {
                return new APIResultDto() { Code = 0, Msg = "资料提交成功，待营销中心审核" };
            }

        }
    }
}

