using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;
using AutomobiliuNuoma.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace AutomobiliuNuoma.Services
{
    public class CacheControlService : ICacheControlService
    {
        private readonly IMongoDBRepository _mongoDBRepository;
        private bool _working = true;

        public CacheControlService(IMongoDBRepository mongoDBRepository)
        {
            _mongoDBRepository = mongoDBRepository;
        }

        public async Task Start()
        {
            _working = true;
            while (_working)
            {
                await Task.Delay(TimeSpan.FromMinutes(2));
                await _mongoDBRepository.DeleteAllAutomobiliai();
                //Task.Delay(TimeSpan.FromMinutes(2)).ContinueWith(t => DeleteAllAutomobiliai());
            }
        }

        public void Stop()
        {
            _working = false;
        }

    }
}

