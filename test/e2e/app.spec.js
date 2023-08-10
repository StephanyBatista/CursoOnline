import { Selector } from 'testcafe';

fixture('App')
    .page('http://localhost:3000')

test('Deve estar funcionando', async t => {
    await t.expect(Selector('title').innerText).eql('Home Page - CursoOnline.Web');
});