﻿// =================================================================== 
// 项目说明
//====================================================================
// YXL @ CopyRight 2006-2010。
// 文件： LogRespository.cs
// 项目名称： 
// 创建时间：2017-05-18
// 负责人：YXL
// ===================================================================

using System;
using System.IO;
using System.Threading.Tasks;
using Core.FileManager;
using Core.Repository.MongoDB;
using IdentityServer4.Extensions;
using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Mongo;
using Mongo.Models;

namespace Service.PermissionSystem
{
    public class LogService : MongoRepository<PermissionSystemLogs>, ILogService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IFileManager _fileManager;

        private readonly string DefaultFileLogPath = Path.Combine(AppContext.BaseDirectory, "Logs");

        public LogService(MongoContext context, IFileManager fileManager,
            IHttpContextAccessor accessor) : base(context.PermissionSystemLogs)
        {
            _fileManager = fileManager;
            _accessor = accessor;
        }

        public async Task Log<TState>(string categoryName, LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter, string fileLogPath)
        {
            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));
            var logEntity = new PermissionSystemLogs
            {
                LogLeve = Convert.ToInt32(logLevel),
                CreateDate = DateTime.Now
            };
            var message = formatter(state, exception);
            if (_accessor.HttpContext != null)
            {
                logEntity.PageUrl = _accessor.HttpContext.Request.GetDisplayUrl();
                logEntity.ReferrerUrl = _accessor.HttpContext.Request.Headers["Referer"].ToString();
                logEntity.IpAddress = _accessor.HttpContext.Connection.RemoteIpAddress?.ToString();
                logEntity.ServerIpAddress = _accessor.HttpContext.Connection.LocalIpAddress?.ToString();
            }
            if (state is PermissionSystemLogs)
                logEntity = state as PermissionSystemLogs;
            logEntity.FullMessage = message;
            logEntity.ShortMessage = categoryName;
            logEntity.KeyWord = logEntity.KeyWord.IsNullOrEmpty() ? categoryName : logEntity.KeyWord;
            logEntity.ShortMessage = logEntity.ShortMessage.IsNullOrEmpty() ? categoryName : logEntity.ShortMessage;
            logEntity.FullMessage = logEntity.FullMessage.IsNullOrEmpty() ? message : logEntity.FullMessage;
            try
            {
                await InsertAsync(logEntity);
            }
            catch (Exception)
            {
                var filePath = Path.Combine(DefaultFileLogPath, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                await _fileManager.WriteAsync(filePath,
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}   {logLevel}   {categoryName}   {message} \r\n");
            }
        }


        public async Task Log<TState>(string categoryName, LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            await Log(categoryName, logLevel, eventId, state, exception, formatter, DefaultFileLogPath);
        }
    }
}