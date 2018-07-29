import { Selector } from 'testcafe';
import Page from './page';

export default class Curso extends Page {
    constructor () {
        super();
        this.url = `${this.urlBase}/Curso/Novo`;
        this.inputNome = Selector('[name="Nome"]');
        this.inputCargaHoraria = Selector('[name="CargaHoraria"]');
        this.selectPublicoAlvo = Selector('[name="PublicoAlvo"]');
        this.opcaoEmpregado = Selector('option[value="Empregado"]');
        this.inputValor = Selector('[name="Valor"]');
        this.salvar = Selector('.btn-success');
    }
}