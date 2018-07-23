import { Selector, RequestLogger } from 'testcafe';

const logger = RequestLogger({url: 'localhost:3000/Curso/Salvar', method: 'post' }, {
    logResponseHeaders: true,
    logResponseBody:    true
});

fixture('Curso')
    .page('localhost:3000/Curso/Novo')
    .requestHooks(logger);

test('Deve criar novo curso', async t => {
    
    await t
        .typeText(Selector('[name="Nome"]'), `Curso ${new Date().getMilliseconds()}`)
        .typeText(Selector('[name="CargaHoraria"]'), '10')
        .typeText(Selector('[name="PublicoAlvo"]'), 'Empregado')
        .typeText(Selector('[name="Valor"]'), '1000')

    await t
        .click(Selector('[name="submit"]'))

    // await t
    //     .expect(Selector('title').innerText).eql('Listagem de cursos - CursoOnline.Web')
    // await t
    //     .expect(logger.contains(r => r.response.statusCode === 200)).ok();

    console.log(await logger.requests);
});

test('Deve validar campos obrigatórios', async t => {
    
    await t
        .click(Selector('[name="submit"]'))

    await t
        .expect(Selector('.toast-error').withText('Nome inválido')).ok()
        .expect(Selector('.toast-error').withText('Carga horária inválida')).ok()
        .expect(Selector('.toast-error').withText('Valor inválido')).ok();
});