import { Selector } from 'testcafe'
import Curso from './pagesmodel/curso';

const curso = new Curso();

fixture('Curso')
    .page(curso.url)

test('Deve criar um novo curso', async t => {

    await t
        .typeText(curso.inputNome, `Curso TestCafé ${new Date().toString()}`)
        .typeText(curso.inputCargaHoraria, '10')
        .click(curso.selectPublicoAlvo)
        .click(curso.opcaoEmpregado)
        .typeText(curso.inputValor, '1000');

    await t
        .click(curso.salvar);

    await t
        .expect(curso.tituloDaPagia.innerText).eql('Listagem de cursos - CursoOnline.Web')
});

test('Deve validar campos obrigatórios', async t => {

    await t
        .click(Selector('.btn-success'));

    await t
        .expect(curso.toastMessage.withText('Nome inválido').count).eql(1)
        .expect(curso.toastMessage.withText('Valor inválido').count).eql(1)
        .expect(curso.toastMessage.withText('Carga horária inválida').count).eql(1);
});
