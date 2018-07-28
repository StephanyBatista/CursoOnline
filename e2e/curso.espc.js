import { Selector, RequestLogger } from 'testcafe';

fixture('Curso')
    .page('localhost:3000/Curso/Novo');

test('Deve criar novo curso', async t => {
    
    await t
        .typeText(Selector('[name="Nome"]'), `Curso ${new Date().getMilliseconds()}`)
        .typeText(Selector('[name="CargaHoraria"]'), '10')
        .typeText(Selector('[name="PublicoAlvo"]'), 'Empregado')
        .typeText(Selector('[name="Valor"]'), '1000')

    await t
        .click(Selector('[name="submit"]'))

    await t
        .expect(Selector('title').innerText).eql('Listagem de cursos - CursoOnline.Web')
});

test('Deve validar campos obrigatórios', async t => {
    
    await t
        .click(Selector('[name="submit"]'))

    await t
        .expect(Selector('.toast-error').withText('Nome inválido')).ok()
        .expect(Selector('.toast-error').withText('Carga horária inválida')).ok()
        .expect(Selector('.toast-error').withText('Valor inválido')).ok();
});