import React, { Component } from 'react';

export class ProductList extends Component {
    static displayName = ProductList.name;

    constructor(props) {
        super(props);
        this.state = { data: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderDataTable(data) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Manufacturer</th>
                        <th>Style</th>
                        <th>Purchase Price</th>
                        <th>Sale Price</th>
                        <th>Quantity On Hand</th>
                        <th>Commission Percent</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(item =>
                        <tr key={item.id}>
                            <td>{item.name}</td>
                            <td>{item.manufacturer}</td>
                            <td>{item.style}</td>
                            <td>{item.purchasePrice}</td>
                            <td>{item.salePrice}</td>
                            <td>{item.quantityOnHand}</td>
                            <td>{item.commisionPercent}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ProductList.renderDataTable(this.state.data);

        return (
            <div>
                <h1 id="tabelLabel">Products</h1>
                {contents}
            </div>
        );
    }

    async populateData() {

        const response = await fetch('/api/product');

        console.log(response);

        const data = await response.json();

        this.setState({ data: data, loading: false });
    }
}
