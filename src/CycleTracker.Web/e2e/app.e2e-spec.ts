import { CycleTrackerPage } from './app.po';

describe('cycle-tracker App', function() {
  let page: CycleTrackerPage;

  beforeEach(() => {
    page = new CycleTrackerPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
