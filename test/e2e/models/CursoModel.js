import BaseModel from './BaseModel';

export default class CursoModel extends BaseModel{
    constructor(){
        super();
        this.url = `${this.urlBase}`;
        this.NomeCampo = '[name="Nome"]';
        this.CargaHorariaCampo = '[name="CargaHoraria"]';
        this.ValorCampo = '[name="Valor"]';
        this.Salvar = '.btn-success'; 
    }
}