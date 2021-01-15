describe("testDivisionCalculations", () => {
  it('Tests that "4 / 2 = 2" is displayed in resultLabel', () => {
    cy.visit("http://localhost/")
    .get('#divisionCalculationsForm').get('#divideFirstNumberInput').type('4')
    .get('#divisionCalculationsForm').get('#divideSecondNumberInput').type('2')
    .get('#divisionCalculationsForm').get('#divideSubmitButton').click()
    .get('#resultLabel').contains("4 / 2 = 2");

    cy.request('DELETE', 'http://localhost/Home/DeleteCalculations?numberOfTestsRun=1');
  })
})
