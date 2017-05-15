using AutoMapper;
using GerenciamentoDeAnuncio.Domain.Entities;
using GerenciamentoDeAnuncio.MVC.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System;

namespace GerenciamentoDeAnuncio.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }

        }

        protected void Configure()
        {
            CreateMap<Anuncio,AnuncioViewModel>();
        }
    }
}