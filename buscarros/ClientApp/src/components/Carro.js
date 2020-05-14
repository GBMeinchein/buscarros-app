import React, { Component } from 'react';

export class Carro extends Component {
    static displayName = Carro.name;

    constructor(props) {
      super(props);
      this.state = { carros: [], loading: true };
    }
  
    componentDidMount() {
      this.populateCarroData();
    }
  
    static renderCarrosTable(carros) {
      return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th></th>
              <th>Título</th>
              <th>Marca</th>
              <th>Preço</th>
              <th>Cidade</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {carros.map(carro =>
              <tr key={carro.title} href={carro.href}>
                <td><img 
                  src={carro.image}
                  alt="new"
                  height="100"
                  />       
                </td>         
                <td>{carro.title}</td>
                <td>{carro.brand}</td>                
                <td width="150">{carro.price}</td>
                <td>{carro.adress}</td>
                <td><a href={carro.href}  target="_blank">Ir para anúncio original</a></td>
              </tr>
            )}
          </tbody>
        </table>
      );
    }
  
    render() {
      let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : Carro.renderCarrosTable(this.state.carros);
  
      return (
        <div>
          <tr>
            <td>
              <select class="browser-default custom-select" name="marcaSelect" 
                      onChange={(e) => this.populateCarroDataByBrand(e.target.value)}>
                <option selected value="">Escolha a marca</option>
                <option value="CHEVROLET">Chevrolet</option>
                <option value="FIAT">Fiat</option>
              </select>
            </td>
            <td>
              <select class="browser-default custom-select" name="cidadeSelect">
                <option selected>Escolha a cidade</option>
                <option value="1">Joinville</option>
                <option value="2">Jaraguá do Sul</option>
                <option value="2">Florianópolis</option>
              </select>
            </td>
          </tr>
          <br/>
          {contents}
        </div>
      );
    }
  
    async populateCarroData() {
      const response = await fetch('api/carro');
      const data = await response.json();
      this.setState({ carros: data, loading: false });
    }

    async populateCarroDataByBrand(brand) {
      const response = await fetch('api/carro?brand='+brand);
      const data = await response.json();
      this.setState({ carros: data, loading: false });
    }
}