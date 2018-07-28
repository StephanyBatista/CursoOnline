import { Selector } from 'testcafe';
import Page from './page';

export default class Curso extends Page {
    constructor () {
        this.urlNovo = `${this.urlBase}/curso/novo`;
        this.nomeInput = Selector('[name="Nome"]');
        this.cargaHorariaInput = Selector('[name="CargaHoraria"]');
        this.publicoAlvo = Selector('[name="PublicoAlvo"]');
        this.valor = Selector('[name="Valor"]');
        this.salvar = Selector('[name="submit"]');
    }
}