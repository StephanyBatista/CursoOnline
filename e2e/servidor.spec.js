import { Selector } from 'testcafe';
import Page from './pagesmodel/page';

const page = new Page();

fixture('Servidor')
    .page(page.urlBase)

test('Validando se está de pé', async t => {
    await t.expect(Selector('title').innerText).eql('Home Page - CursoOnline.Web');
});