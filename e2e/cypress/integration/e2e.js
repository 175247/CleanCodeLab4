// <reference types="cypress" />

context('Actions', () => {
  beforeEach(() => {
    cy.visit('http://cleancodelab4')
  })

  // https://on.cypress.io/interacting-with-elements

  it('.type() - type into a DOM element', () => {
    // https://on.cypress.io/type
    cy.get('input[id="additionFirstNumber"]')
      .type('1').should('have.value', '1')

    cy.get('input[id="additionSecondNumber"]')
    .type('5').should('have.value', '5')

    cy.get('#additionForm').submit()

    cy.get('label[id="resultLabel"]').should('have.text', '1 + 5 = 6')
    
    cy.get('input[id="idInput"]').invoke('val').then((val1)=> {
      cy.request('DELETE', 'http://mysql:5000/api/Calculations/'+val1)
    })    
  })
})