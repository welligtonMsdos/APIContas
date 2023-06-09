﻿using System.ComponentModel.DataAnnotations;

namespace APIContas.Data.Dtos;

public class CreateCategoriaDto
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    [Display(Name = "Descrição")]
    [MinLength(5, ErrorMessage = "{0} necessário mínimo 5 caracteres")]
    [MaxLength(30, ErrorMessage = "{0} máximo 30 caracteres")]
    public string Descricao { get; set; }
}
