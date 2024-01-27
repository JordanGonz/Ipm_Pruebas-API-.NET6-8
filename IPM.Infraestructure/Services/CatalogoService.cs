using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;

public class CatalogoService : ICatalogoService
{
    private readonly ICatalogoRepository _catalogoRepository;
    private readonly IMapper _mapper;

    public CatalogoService(ICatalogoRepository catalogoRepository, IMapper mapper)
    {
        _catalogoRepository = catalogoRepository;
        _mapper = mapper;
    }

    public async Task<List<CatalogoDto>> ObtenerTodosLosCatalogoAsync(string nemonico)
    {
        var catalogos = await _catalogoRepository.ObtenerTodosAsync(nemonico);
        return _mapper.Map<List<CatalogoDto>>(catalogos);
    }
    public async Task<List<CatalogoMostrarNombre>> ObtenerTodosLosNombresdeSuNemonico()
    {
        var catalogos = await _catalogoRepository.ObtenerTodosLosNombresAsync();
        return _mapper.Map<List<CatalogoMostrarNombre>>(catalogos);
    }


    public async Task<CatalogoDto> ObtenerCatalogoPorIdAsync(int idCatalogo)
    {
        var catalogo = await _catalogoRepository.ObtenerPorIdAsync(idCatalogo);
        return _mapper.Map<CatalogoDto>(catalogo);
    }






    public async Task<bool> CrearCatalogoAsync(CatalogoCreacionDTO catalogoDto)
    {
        var nuevoCatalogo = _mapper.Map<Catalogo>(catalogoDto);

        nuevoCatalogo.Estado = IPMConstants.ESTADO_ACTIVO;

        if (nuevoCatalogo != null)
        {
            return await _catalogoRepository.CrearAsync(nuevoCatalogo);
        }
        return false;
    }




    public async Task<bool> ActualizarCatalogoAsync(int IdCatalogo, CatalogoDto catalogoDto)
    {
        var catalogo = await _catalogoRepository.ObtenerPorIdAsync(IdCatalogo);

        if (catalogo == null)
        {
            return false;
        }

        _mapper.Map(catalogoDto, catalogo);
        await _catalogoRepository.ActualizarAsync(catalogo);

        return true;
    }


    public async Task<bool> EliminarCatalogoAsync(int idCatalogo)
    {
        var catalogo = await _catalogoRepository.ObtenerPorIdAsync(idCatalogo);
        if (catalogo == null)
        {
            return false;
        }
        catalogo.Estado = IPMConstants.ESTADO_ACTIVO;

        return await _catalogoRepository.EliminarAsync(idCatalogo);
    }

}
