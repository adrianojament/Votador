using api.shared.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.domain.Entities.Standard
{
    public abstract class BaseEntity
    {
        DateTime? _CriadoEm;
        DateTime? _AtualizadoEm;

        [Key]
        public Guid Id { get; set; }

        public DateTime? AtualizadoEm
        {
            get
            {
                if (_AtualizadoEm == null)
                {
                    _AtualizadoEm = Helpers.GetDateTimeBrasilian();
                }
                return _AtualizadoEm;
            }
            set => _AtualizadoEm = value;
        }
        public DateTime? CriadoEm
        {
            get
            {
                if (_CriadoEm == null)
                {
                    _CriadoEm = Helpers.GetDateTimeBrasilian();
                }
                return _CriadoEm;
            }
            set => _CriadoEm = value;
        }
    }
}
