class Struct_test extends React.Component {
    render() {
        return <tr>
            <td>{this.props.dona}</td>
            <td>{this.props.qualidade}</td>
        </tr>;
    }
}

class Report extends React.Component {
    render() {
        return <div className="ui text container">
            <h1 className="ui dividing header">Relatório de teste</h1>
            {this.props.int_list.map(e => <span>Recebi esse inteiro aqui: {e}<br /></span>)}
            <table className="ui celled black compact table">
                <thead>
                    <tr>
                        <th>Dona</th>
                        <th>qualidade</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.struct_list.map(e => <Struct_test {...e} />)}
                </tbody>
            </table>

            <span className="assinatura">Assinatura do cliente</span>
        </div>;
    }
}

ReactDOM.render(<Report {...window.data} />, document.getElementById('root'));