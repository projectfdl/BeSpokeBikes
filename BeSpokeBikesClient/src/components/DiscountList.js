import React, { Component } from 'react';

export class DiscountList extends Component {
    static displayName = DiscountList.name;

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
                        <th>Description</th>
                        <th>ProductId</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Percent</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(item =>
                        <tr key={item.id}>
                            <td>{item.description}</td>
                            <td>{item.productId}</td>
                            <td>{item.startDate}</td>
                            <td>{item.endDate}</td>
                            <td>{item.discountPercent}</td>
                            <td>{item.discountAmount}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : DiscountList.renderDataTable(this.state.data);

        return (
            <div>
                <h1 id="tabelLabel">Discounts</h1>
                {contents}
            </div>
        );
    }

    async populateData() {

        const response = await fetch('/api/discount');

        console.log(response);

        const data = await response.json();

        this.setState({ data: data, loading: false });
    }
}
