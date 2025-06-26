namespace ClinicaGoF.Application.DTOs.ViewModels
{
	public record PacienteViewModel(
		Guid Id,
		string Nome,
		string Documento,
		DateTime DataNascimento,
		DateTime DataCadastro
	);
}
