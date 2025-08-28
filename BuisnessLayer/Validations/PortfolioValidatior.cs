using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Validations
{
    public class PortfolioValidatior : AbstractValidator<Portfolio>
    {
        public PortfolioValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adı Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Adı Boş Geçilemez");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel2 Adı Boş Geçilemez");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Görsel1 Adı Boş Geçilemez");
            RuleFor(x => x.Image2).NotEmpty().WithMessage("Görsel2 Adı Boş Geçilemez");
            RuleFor(x => x.Image3).NotEmpty().WithMessage("Görsel3 Adı Boş Geçilemez");
            RuleFor(x => x.Image4).NotEmpty().WithMessage("Görsel4 Adı Boş Geçilemez");
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform Adı Boş Geçilemez");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Tamamlanma Durumu Boş Geçilemez");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Proje Urlsi  Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Adı Boş Geçilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer Adı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje Adı en az 5 karakterden oluşmalıdır");
        }
    }
}
