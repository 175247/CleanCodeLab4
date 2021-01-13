describe("testAdditionCalculations", () => {
  it('Tests that "3 + 3 = 6" is displayed in resultLabel', () => {
    cy.visit("https://localhost:49215/")
    cy.get('#additionCalculationsForm').get('#addFirstNumberInput').type('3')
    cy.get('#additionCalculationsForm').get('#addSecondNumberInput').type('3')
    cy.get('#additionCalculationsForm').get('#addSubmitButton').click()
    cy.get('#resultLabel').contains("3 + 3 = 6");
  })

  it('Tests that "4 / 2 = 2" is displayed in resultLabel', () => {
    cy.get('#divisionCalculationsForm').get('#divideFirstNumberInput').type('4')
    cy.get('#divisionCalculationsForm').get('#divideSecondNumberInput').type('2')
    cy.get('#divisionCalculationsForm').get('#divideSubmitButton').click()
    cy.get('#resultLabel').contains("4 / 2 = 2");
  })

  it('Tests that "2 * 4 = 8" is displayed in resultLabel', () => {
    cy.get('#multiplicationCalculationsForm').get('#multiplyFirstNumberInput').type('2')
    cy.get('#multiplicationCalculationsForm').get('#multiplyFecondNumberInput').type('4')
    cy.get('#multiplicationCalculationsForm').get('#multiplySubmitButton').click()
    cy.get('#resultLabel').contains("2 * 4 = 8");
  })
})
