import { Selector } from 'testcafe';
import CursoModel from './models/CursoModel';
import faker from 'faker';

const model = new CursoModel();

fixture('Curso')
    .page('http://localhost:3000/curso/novo')

test('Deve criar um curso', async t => {
    
    //Arrange
    await t
        .typeText(model.NomeCampo, faker.commerce.productName())
        .typeText(model.CargaHorariaCampo, faker.random.number(10, 100).toString())
        .typeText(model.ValorCampo, faker.commerce.price());

    //Act
    await t.click(model.Salvar);

    //Assert
    await t.expect(Selector(model.tituloDaPagina).innerText).eql('Listagem de cursos - CursoOnline.Web');
});

test('Deve validar campos obrigatórios', async t => {
    
    //Act
    await t.click('.btn-success');
    
    //Assert
    await t
        .expect(Selector('.toast-message').withText('Nome inválido').count).eql(1)
        .expect(Selector('.toast-message').withText('Valor inválido').count).eql(1)
        .expect(Selector('.toast-message').withText('Carga horária inválida').count).eql(1);
});

test('Deve listar cursos salvos', async t => {
    
    //Act
    await t.navigateTo('http://localhost:3000/curso');
    
    //Assert
    await t
        .expect(Selector('.table tbody tr').count).gte(1)
        .takeScreenshot('listagem_de_cursos.png');
});